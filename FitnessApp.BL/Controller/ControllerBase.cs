using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace FitnessApp.BL.Controller
{
    public abstract class ControllerBase
    {
        //private readonly IDataSaver manager = new Seri
        protected void Save(string fileName, object item)
        {
            var formatter = new BinaryFormatter();
            using (var fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, item);
            }
        }

        protected T Load<T>(string fileName)
        {
            var formatter = new BinaryFormatter();
            using (var fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {

                T items = default(T);
                if (fs.Length > 0 && formatter.Deserialize(fs) is T )
                {
                    return items;
                }
                else
                {
                    return default(T);
                }
            }
        }
    }
}
