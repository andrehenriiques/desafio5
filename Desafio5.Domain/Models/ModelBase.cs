using System.Text.Json.Serialization;

namespace Desafio5.Domain.Models
{
    public class ModelBase
    {
        public string Id { get; set; }
        [JsonIgnore]
        public DateTime CreatedDate { get; set; }
        [JsonIgnore]
        public DateTime? UpdatedDate { get; set; }

        [JsonIgnore]
        public bool Active { get; set; }

        public void NewRegister()
        {
            CreatedDate = DateTime.Now;
            UpdatedDate = null;
            Active = true;
        }
        public void AtualizarRegistro()
        {
            UpdatedDate = DateTime.Now;
            Active = true;
        }
        public void InativarRegistro()
        {
            Active = false;
        }
    }
}