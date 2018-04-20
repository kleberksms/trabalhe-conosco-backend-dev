using System;
using System.Collections.Generic;
using System.IO;
using PicPay.LoadCsv;
using PicPay.SharedKernel.Models;
using Xunit;

namespace PayPay.Test
{
    public class CsvTest
    {
        private readonly Csv _csv;
        public CsvTest()
        {
            _csv = new Csv();
        }
        [Fact]
        public void LoadTest()
        {
            var location = Path.Combine(
                System.Reflection
                    .Assembly.GetExecutingAssembly().Location
                    .Split(new [] { "bin" }, StringSplitOptions.None)[0],"Database","users.csv");

            Assert.IsType<List<User>>(_csv.Load(location));
        }
    }
}
