﻿using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
namespace Castellano.Membresia
{
	public static class Account
	{
        public static LoginStatus DoLogin(int cuerpo, char digito, string password)
		{
			Persona persona = Persona.Get(cuerpo, digito);
			Usuario usuario = Usuario.Get(cuerpo, digito);

			if (persona == null) return LoginStatus.InvalidRunOrPassword;

			if (usuario == null)
			{
				Account.RegisterLogin(persona);

				usuario = Usuario.Get(cuerpo, digito);
			}

			//string clave = Account.DecodePassword(usuario.Password);

			if (!Account.EncryptPassword(password).Equals(usuario.Password))
			{
				UpdateFailureCount(usuario);

				return LoginStatus.InvalidRunOrPassword;
			}

			if (usuario.FechaIntentoFallido.HasValue && usuario.FechaIntentoFallido.Value.AddDays(1).CompareTo(DateTime.Now) > 0 && usuario.NumeroIntentosFallidos >= 10)
			{
				return LoginStatus.UserLocked;
			}

			UnLock(usuario);

			if (!usuario.Aprobado)
			{
				return LoginStatus.UserApprovedOut;
			}

			if (Aplicacion.GetAll(persona).Count == 0)
			{
				return LoginStatus.NotAccessAllowed;
			}

			return LoginStatus.Success;
		}

        public static PasswordRecoveryStatus DoPasswordRecovery(int cuerpo, char digito)
		{
			Persona persona = Persona.Get(cuerpo, digito);
			Usuario usuario = Usuario.Get(cuerpo, digito);

			if (persona == null) return PasswordRecoveryStatus.UserNotFound;

			if (usuario == null)
			{
				Account.RegisterLogin(persona);

				usuario = Usuario.Get(cuerpo, digito);
			}

			if (string.IsNullOrEmpty(persona.Email)) return PasswordRecoveryStatus.EmailNotRegistered;

			string to = string.Empty;
			string subject = string.Empty;
			string body = string.Empty;

			to = persona.Email.ToLower();
			subject = "Información solicitada de sistemas NetCore";
			body = "Estimado(a) " + persona.Nombre + ", hemos recibido una solicitud de recuperación de contraseña en la aplicación NetCore, por lo que le hacemos llegar los datos de acceso para el inicio de sesión." + System.Environment.NewLine;
			body += "R.U.N.: " + string.Format("{0}-{1}", cuerpo, digito) + System.Environment.NewLine;
			body += "Contraseña: " + Account.DecodePassword(usuario.Password) + System.Environment.NewLine;
			body += "Esperamos que la información le sea de utilidad." + System.Environment.NewLine;
			body += "Atte," + System.Environment.NewLine;
			body += "El equipo NetCore";

			Helper.SendMail(to, subject, body);

			return PasswordRecoveryStatus.Success;
		}

		public static ChangePasswordStatus DoChangePassword(Usuario usuario, string newPassword, string confirmPassword)
		{
			using (Context context = new Context())
			{
                if (!newPassword.Equals(confirmPassword))
                {
                    return ChangePasswordStatus.WrongConfirmPassword;
                }

                if (newPassword.Length < 7)
                {
                    return ChangePasswordStatus.TooShortNewPassword;
                }

				usuario.Password = EncryptPassword(newPassword);
				usuario.Save(context);

				context.SubmitChanges();

				return ChangePasswordStatus.Success;
			}
		}

        public static ChangePasswordStatus DoChangePassword(Usuario usuario, string currentPassword, string newPassword, string confirmPassword)
		{
			using (Context context = new Context())
			{
                if (!EncryptPassword(currentPassword).Equals(usuario.Password))
                {
                    return ChangePasswordStatus.WrongCurrentPassword;
                }

                if (!newPassword.Equals(confirmPassword))
                {
                    return ChangePasswordStatus.WrongConfirmPassword;
                }

                if (newPassword.Length < 8)
                {
                    return ChangePasswordStatus.TooShortNewPassword;
                }

				usuario.Password = EncryptPassword(newPassword);
				
				usuario.Save(context);

				context.SubmitChanges();

				return ChangePasswordStatus.Success;
			}
		}

        public static void RegisterLogin(Persona persona)
		{
			using (Context context = new Context())
			{
				DateTime createDate = DateTime.Now;

				Usuario usuario = new Usuario
				{
					Id = persona.Id,
					Password = EncryptPassword(persona.RunCuerpo.ToString()),
					Aprobado = true,
					Bloqueado = false,
                    Creacion = createDate,
					UltimaActividad = createDate,
					UltimoAcceso = createDate,
					UltimoCambioPassword = null,
					UltimoDesbloqueo = null,
					NumeroIntentosFallidos = 0,
					FechaIntentoFallido = null,
                    AperturaPeriodoRemuneracion = false
				};

				usuario.Save(context);

				context.SubmitChanges();

				if (!string.IsNullOrEmpty(persona.Email))
				{
					string to = string.Empty;
					string subject = string.Empty;
					string body = string.Empty;

					to = persona.Email.ToLower();
					subject = "Bienvenido a NetCore";
					body += "Bienvenido a NetCore, estamos muy contentos de que haya ingresado a nuestros sistemas y esperamos sean de su agrado." + System.Environment.NewLine;
					body += "Recuerde que su clave de acceso es el cuerpo de su R.U.N., pero le solicitamos encarecidamente asignar una contraseña distinta para asegurar su información, recuerde que usted es el responsable de todo lo que se haga con su cuenta." + System.Environment.NewLine;
					body += "Para asignar una nueva contraseña ingrese al sistema y presione el botón Cambiar contraseña de la parte superior derecha de la pantalla, el sistema le solicitará la contraseña actual y que ingrese dos veces la nueva contraseña para evitar asegurar que no hayan errores de tipeo." + System.Environment.NewLine;
					body += "Atte," + System.Environment.NewLine;
					body += "El equipo NetCore";

					Helper.SendMail(to, subject, body);
				}
			}
		}

		public static void UnLock(Usuario usuario)
		{
			if (usuario.Bloqueado && !string.IsNullOrEmpty(usuario.Persona.Email))
			{
				string to = string.Empty;
				string subject = string.Empty;
				string body = string.Empty;

				to += usuario.Persona.Email;
				subject += "Cuenta desbloqueada";
				body += "Estimado usuario, su cuenta de acceso a los sistemas NetCore ha sido desbloqueada, por lo que ya puede ingresar cuando guste." + System.Environment.NewLine;
				body += "Recuerde cambiar períodicamente su clave y que ante 10 intentos fallidos consecutivos el sistema bloqueará por seguridad su cuenta por un plazo de 24 hrs., por lo que recomendamos, en el caso de olvidar su contraseña, acceder al menú \"Recuperar contraseña\" (Deberá tener registrado una cuenta de correos para recibir la información)." + System.Environment.NewLine;
				body += "Para asignar una nueva contraseña ingrese al sistema y presione el botón Cambiar contraseña de la parte superior derecha de la pantalla, el sistema le solicitará la contraseña actual y que ingrese dos veces la nueva contraseña para evitar asegurar que no hayan errores de tipeo." + System.Environment.NewLine;
				body += "Atte," + System.Environment.NewLine;
				body += "El equipo NetCore";

				//Helper.SendMail(to, subject, body);

				usuario.UltimoDesbloqueo = DateTime.Now;
			}

			using (Context context = new Context())
			{
				Usuario u = context.Usuarios.Single<Usuario>(x => x.Id == usuario.Id);

				u.UltimoDesbloqueo = usuario.UltimoDesbloqueo;
				u.UltimaActividad = DateTime.Now;
				u.UltimoAcceso = DateTime.Now;
				u.Bloqueado = false;
				u.NumeroIntentosFallidos = 0;
				u.FechaIntentoFallido = null;

				u.Save(context);

				context.SubmitChanges();
			}
		}

        public static void Lock(Usuario usuario)
		{
			using (Context context = new Context())
			{
				Usuario u = context.Usuarios.Single<Usuario>(x => x.Id == usuario.Id);

				u.UltimoDesbloqueo = usuario.UltimoDesbloqueo;
				u.UltimaActividad = DateTime.Now;
				u.UltimoAcceso = DateTime.Now;
				u.Bloqueado = true;
				u.NumeroIntentosFallidos = 10;
				u.FechaIntentoFallido = DateTime.Now;

				u.Save(context);

				context.SubmitChanges();
			}
		}

        public static void UpdateFailureCount(Usuario usuario)
		{
			if (!usuario.FechaIntentoFallido.HasValue) usuario.FechaIntentoFallido = DateTime.Now;
			usuario.NumeroIntentosFallidos++;

			if (!usuario.Bloqueado && usuario.NumeroIntentosFallidos >= 10)
			{
				usuario.Bloqueado = true;

				if (!string.IsNullOrEmpty(usuario.Persona.Email))
				{
					string to = string.Empty;
					string subject = string.Empty;
					string body = string.Empty;

					to += usuario.Persona.Email;
					subject += "Cuenta NetCore Bloqueada";
					body += "Estimado usuario, su cuenta de acceso a los sistemas NetCore ha sido bloqueada por 24 hrs, al exceder los 10 intentos fallidos de acceso permitidos." + System.Environment.NewLine;
					body += "Este es un mecanismo para su seguridad que evita accesos no autorizados por \"Fuerza bruta\"" + System.Environment.NewLine;
					body += "Su acceso será restablecido el día " + DateTime.Today.AddDays(1).ToShortDateString() + " a las " + DateTime.Today.AddDays(1).ToShortTimeString() + "." + System.Environment.NewLine;
					body += "Atte," + System.Environment.NewLine;
					body += "El equipo NetCore";

					//Helper.SendMail(to, subject, body);

					usuario.UltimaActividad = DateTime.Now;
				}
			}

			using (Context context = new Context())
			{
				Usuario u = context.Usuarios.Single<Usuario>(x => x.Id == usuario.Id);
				u.Bloqueado = usuario.Bloqueado;
				u.NumeroIntentosFallidos = usuario.NumeroIntentosFallidos;
				u.FechaIntentoFallido = usuario.FechaIntentoFallido;

				context.SubmitChanges();
			}
		}

        public static string EncryptPassword(string unencodePassword)
		{
			String password = "21F090935F6E49C2C797F69BBAAD8402ABD2EE0B667A8B44EA7DD4374267A75D7 AD972A119482D15A4127461DB1DC347C1A63AE5F1CCFAACFF1B72A7F0A281B";
			String hashAlgorithm = "MD5";
			String saltValue = "21F090935F6E49C2C797F69BBAAD8402ABD2EE0B667A8B44EA7DD4374267A75D7 AD972A119482D15A4127461DB1DC347C1A63AE5F1CCFAACFF1B72A7F0A281B";
			Int32 keySize = 192;
			Int32 passwordIteration = 1;
			String initialVector = ("21F090935F6E49C2C797F69BBAAD8402ABD2EE0B667A8B44EA7DD4374267A75D7 AD972A119482D15A4127461DB1DC347C1A63AE5F1CCFAACFF1B72A7F0A281B").Remove(16);

			Byte[] InitialVectorBytes = Encoding.ASCII.GetBytes(initialVector);
			Byte[] saltValueBytes = Encoding.ASCII.GetBytes(saltValue);
			Byte[] plainTextBytes = Encoding.UTF8.GetBytes(unencodePassword);

			PasswordDeriveBytes passwordBytes = new PasswordDeriveBytes(password, saltValueBytes, hashAlgorithm, passwordIteration);

			Byte[] keyBytes = passwordBytes.GetBytes(keySize / 8);

			RijndaelManaged symmetricKey = new RijndaelManaged();

			symmetricKey.Mode = CipherMode.CBC;

			ICryptoTransform encryptor = symmetricKey.CreateEncryptor(keyBytes, InitialVectorBytes);

			MemoryStream memoryStream = new MemoryStream();

			CryptoStream cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write);

			cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
			cryptoStream.FlushFinalBlock();

			Byte[] cipherTextBytes = memoryStream.ToArray();

			memoryStream.Close();
			cryptoStream.Close();

			String encodePassword = System.Convert.ToBase64String(cipherTextBytes);

			return encodePassword;
		}

        public static string DecodePassword(string encodePassword)
		{
			String password = "21F090935F6E49C2C797F69BBAAD8402ABD2EE0B667A8B44EA7DD4374267A75D7 AD972A119482D15A4127461DB1DC347C1A63AE5F1CCFAACFF1B72A7F0A281B";
			String hashAlgorithm = "MD5";
			String saltValue = "21F090935F6E49C2C797F69BBAAD8402ABD2EE0B667A8B44EA7DD4374267A75D7 AD972A119482D15A4127461DB1DC347C1A63AE5F1CCFAACFF1B72A7F0A281B";
			Int32 keySize = 192;
			Int32 passwordIteration = 1;
			String initialVector = ("21F090935F6E49C2C797F69BBAAD8402ABD2EE0B667A8B44EA7DD4374267A75D7 AD972A119482D15A4127461DB1DC347C1A63AE5F1CCFAACFF1B72A7F0A281B").Remove(16);
			Byte[] InitialVectorBytes = Encoding.ASCII.GetBytes(initialVector);
			Byte[] saltValueBytes = Encoding.ASCII.GetBytes(saltValue);
			Byte[] cipherTextBytes = System.Convert.FromBase64String(encodePassword);

			PasswordDeriveBytes passwordBytes = new PasswordDeriveBytes(password, saltValueBytes, hashAlgorithm, passwordIteration);

			Byte[] keyBytes = passwordBytes.GetBytes(keySize / 8);

			RijndaelManaged symmetricKey = new RijndaelManaged();

			symmetricKey.Mode = CipherMode.CBC;

			ICryptoTransform decryptor = symmetricKey.CreateDecryptor(keyBytes, InitialVectorBytes);
			MemoryStream memoryStream = new MemoryStream(cipherTextBytes);
			CryptoStream cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);

			Byte[] plainTextBytes = new Byte[cipherTextBytes.Length];

			Int32 decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);

			memoryStream.Close(); cryptoStream.Close();

			String plainText = Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount);

			return plainText;
		}
	}
}
