using System;
using System.Collections.Generic;
using System.IO;
using PicPay.SharedKernel.Models;

namespace PicPay.LoadCsv
{
    public class Csv
    {
        public List<User> Load(string location)
        {
            var userList = new List<User>();
            var file = Path.Combine(Path.GetTempPath(), location);
            using (var streamReader = System.IO.File.OpenText(file))
            {
                while (!streamReader.EndOfStream)
                {
                    var line = streamReader.ReadLine();
                    if (line == null) continue;

                    var data = line.Split(new[] { ',' });
                   userList.Add(new User(Guid.Parse(data[0]), data[1], data[2]));
                }
            }
            return userList;
        }
    }
}
