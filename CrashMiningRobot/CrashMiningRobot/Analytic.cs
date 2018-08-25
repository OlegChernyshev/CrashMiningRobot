using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrashMiningRobot
{
    /// <summary>
    /// Структура ставки
    /// </summary>
    public struct BET
    {
        public double crash;
        public int rate;
    }

    /// <summary>
    /// Анализирует банк и вычисляет требуемые коэф.
    /// </summary>
    public class Analytic
    {
        #region Переменные
        // Изночально заданные значения
        public int Bank { get; set; } // банк на который мы играем
        public int Rate { get; set; } // оптимальная ставка которую нужно делать
        public double Coefficient { get; set; }

        public double Min { get; set; } // Минимально возможный коэф. краша
        public double Max { get; set; } // Максимально возможный коэф. краша

        // текущие значение во время игры
        public double bank { get; set; } // текущий банк
        public double rate { get; set; } // текущая ставка
        public double crash { get; set; } // последний краш
        Random random = null;
        #endregion

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="bank">Банк на который мы играем</param>
        /// <param name="rate">Ставка которую мы делаем</param>
        /// <param name="coefficient">Коэф. на который нужно домножать ставку при пройгрыше</param>
        /// <param name="min">Минимальный Коэффициент</param>
        /// <param name="max">Максимальный Коэффициент</param>
        public Analytic(int bank, int rate, double coefficient, double min, double max)
        {
            Bank = bank;
            Rate = rate;
            Coefficient = coefficient;
            Min = min;
            Max = max;

            random = new Random();
        }

        private Analytic() { }

        /// <summary>
        /// Возвращает структуру с начальными условиями
        /// </summary>
        /// <returns>Структура  начальными условиями</returns>
        public BET GetBET()
        {
            BET bet = new BET();
            bet.rate = Rate;
            bet.crash = Crash(Min, Max);
            return bet;
        }

        public BET Processing(bool win)
        {
            BET bet = new BET();
            if (win)
            {
                bank += rate * crash;
                rate = 0;
                bet.rate = Rate;
            }
            else
            {
                bank -= rate;
                rate *= Coefficient;
                bet.rate = (int)Math.Round(rate);
            }
            crash = Crash(Min, Max);
            bet.crash = crash;
            return bet;
        }

        /// Платежеспособный ли игрок (может-ли он поддержать ставку)
        public bool isSolvent (BET bet)
        {
            if (bet.rate > bank) return false;
            return true; ;
        }

        /// Генерация краша
        private double Crash(double min, double max)
        {
            random = new Random();
            double value = min - random.NextDouble() * (min - max);
            return Math.Round(value, 2);
        }
    }
}