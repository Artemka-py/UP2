using System;
using System.Security.Cryptography;

namespace HashDll
{
    public class HashClass
    {
        /// <summary>
        /// Производит шифрацию, предусматевающую различие шифрации одинаковых паролей,
        /// вызываемая при регистрации пользователя или изменении пароля
        /// </summary>
        /// <param name="password">Введенный пользователем пароль</param>
        /// <returns></returns>
        public string HashPassword(string password)
        {
            byte[] salt;
            byte[] buffer2;
            if (password == null)
            {
                throw new ArgumentNullException("password");
            }
            //проверка на пустые значения пароля

            using (Rfc2898DeriveBytes bytes = new Rfc2898DeriveBytes(password, 0x10, 0x3e8))
            {
                salt = bytes.Salt;
                buffer2 = bytes.GetBytes(0x20);
            }
            //создание ключа - массива данных, содержащих соль и основу
            //присвоение значений переменным

            byte[] dst = new byte[0x31];

            Buffer.BlockCopy(salt, 0, dst, 1, 0x10);
            //копирование соли в конечный массив

            Buffer.BlockCopy(buffer2, 0, dst, 0x11, 0x20);
            //копирование основы в конечный массив

            return Convert.ToBase64String(dst);
        }

        //Определение идентичности массивов байтов 
        private bool ByteArrayCompare(byte[] a1, byte[] a2)
        {
            if (a1.Length != a2.Length)
                return false;

            for (int i = 0; i < a1.Length; i++)
                if (a1[i] != a2[i])
                    return false;

            return true;
        }

        /// <summary>
        /// Проверка пароля введенного пользователем на идентичность с шифрованным паролем в базе данных
        /// вызываемая при вводе пароля при попытке входа
        /// </summary>
        /// <param name="hashedPassword">Зашифрованный пароль в базе</param>
        /// <param name="password">Пароль введенный пользователем</param>
        /// <returns></returns>
        public bool VerifyHashedPassword(string hashedPassword, string password)
        {
            byte[] buffer4;
            if (hashedPassword == null)
            {
                return false;
            }
            //проверка на пустые значения шифрованного пароля

            if (password == null)
            {
                throw new ArgumentNullException("password");
            }
            //проверка на пустые значения введенного пароля

            byte[] src = Convert.FromBase64String(hashedPassword);
            //конвертация шифрокода из строки в массив байтов

            if ((src.Length != 0x31) || (src[0] != 0))
            {
                return false;
            }

            byte[] dst = new byte[0x10];
            Buffer.BlockCopy(src, 1, dst, 0, 0x10);
            byte[] buffer3 = new byte[0x20];
            Buffer.BlockCopy(src, 0x11, buffer3, 0, 0x20);
            using (Rfc2898DeriveBytes bytes = new Rfc2898DeriveBytes(password, dst, 0x3e8))
            {
                buffer4 = bytes.GetBytes(0x20);
            }
            //генерирует ключ с такой же солью и присваивает её

            return ByteArrayCompare(buffer3, buffer4);
            //возвращает результат сравнения
        }
    }
}
