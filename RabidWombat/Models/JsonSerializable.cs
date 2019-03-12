using Newtonsoft.Json;
using System.IO;

namespace RabidWombat.Models
{
    /// <summary>
    /// Represents an object that can be written to and read from a file as JSON.
    /// </summary>
    public abstract class JsonSerializable<T>
    {
        /// <summary>
        /// Saves this object to a file as JSON.
        /// </summary>
        /// <param name="fileName">The filename to write to.</param>
        public void Save(string fileName)
        {
            var writer = new StreamWriter(fileName);
            writer.Write(JsonConvert.SerializeObject(this, Formatting.Indented));
            writer.Flush();
            writer.Close();
        }

        /// <summary>
        /// Reads an object of type T from a JSON file.
        /// </summary>
        /// <param name="filename">The filename to read from.</param>
        /// <returns></returns>
        public static T FromFile(string filename)
        {
            var reader = new StreamReader(filename);
            var obj = JsonConvert.DeserializeObject<T>(reader.ReadToEnd());
            reader.Close();
            return obj;
        }
    }
}
