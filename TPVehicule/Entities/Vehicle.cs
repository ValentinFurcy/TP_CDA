using System.Text.Json.Serialization;

namespace Entities
{
    [JsonDerivedType(typeof(Car), typeDiscriminator: "car")]
    [JsonDerivedType(typeof(Truck), typeDiscriminator: "truck")]
    public abstract class Vehicle
    {
		public string? Modele { get; set; }

		private string? marque;

		public string? Marque
		{
			get { return marque; }

			set 
			{
				bool isValid = true; 
				foreach (char c in value) 
				{
					if (char.IsDigit(c)) 
					{
						isValid = false;
						break;
					}
				}
				marque = isValid ? value : throw new Exception("La marque ne peut pas contenir de caractères numériques.");
			}
		}

		private string? numero;

		public string? Numero
		{
			get { return numero; }

			set 
			{              
                if (!string.IsNullOrEmpty(value) && value.Length >= 4 && value.Length <= 6) 
				{
                    bool isValid = true;

                    foreach (char c in value)
                    {
                        if (!char.IsDigit(c))
                        {
                            isValid = false;
							break;
                        }
                    }
                    numero = isValid ? value : throw new Exception("Le numéros doit contenir entre 4 et 6 caratères numériques uniquement");
                } 
				else throw new Exception("Le numéros doit contenir entre 4 et 6 caratères numériques");
			}
		}

        public override string ToString()
        {
            return $"Marque: {Marque}, Modèle: {Modele}, Numéro: {Numero}"; 
        }

    }
}
