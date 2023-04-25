using System;
namespace LINQ
{
    internal class GasStation
    {
        /// <summary>
        /// Цена бензина за литр
        /// </summary>
        public int CostOfOneLiter { get; set; }
        /// <summary>
        /// Марка бензина
        /// </summary>
        public int BrandOfGasoline { get; set; }
        /// <summary>
        /// Компания, предоставляющая бензин
        /// </summary>
        public string Company { get; set; }
        /// <summary>
        /// Улица
        /// </summary>
        public string? Street { get; set; }
    }
}

