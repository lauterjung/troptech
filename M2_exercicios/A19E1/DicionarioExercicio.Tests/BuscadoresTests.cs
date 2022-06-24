using DicionarioExercicio.Library;
using NUnit.Framework;

namespace DicionarioExercicio.Tests
{
    public class BuscadoresTests
    {

        [Test]
        public void ComecaComN_AvaliarCriterio_StartsWithNUpper_ReturnsTrue()
        {
            // arrange 
            ComecaComN comecaComN = new ComecaComN();
            string word = "Nice";

            // act
            bool result = comecaComN.AvaliarCriterio(word);
            
            // assert
            Assert.True(result);

        }
        [Test]
        public void ComecaComN_AvaliarCriterio_StartsWithNLower_ReturnsTrue()
        {
            // arrange 
            ComecaComN comecaComN = new ComecaComN();
            string word = "nice";

            // act
            bool result = comecaComN.AvaliarCriterio(word);
            
            // assert
            Assert.True(result);

        }
        
        [Test]
        public void ComecaComN_AvaliarCriterio_StartsWithOther_ReturnsFalse()
        {
            // arrange 
            ComecaComN comecaComN = new ComecaComN();
            string word = "Bad";

            // act
            bool result = comecaComN.AvaliarCriterio(word);
            
            // assert
            Assert.False(result);            
        }

        [Test]
        public void TerminaComO_AvaliarCriterio_EndsWithOUpper_ReturnsTrue()
        {
            // arrange 
            TerminaComO terminaComO = new TerminaComO();
            string word = "CertO";

            // act
            bool result = terminaComO.AvaliarCriterio(word);
            
            // assert
            Assert.True(result);
        }

        [Test]
        public void TerminaComO_AvaliarCriterio_EndsWithOLower_ReturnsTrue()
        {
            // arrange 
            TerminaComO terminaComO = new TerminaComO();
            string word = "Certo";

            // act
            bool result = terminaComO.AvaliarCriterio(word);
            
            // assert
            Assert.True(result);
        }
        
        [Test]
        public void TerminaComO_AvaliarCriterio_EndsWithOther_ReturnsFalse()
        {
            // arrange 
            TerminaComO terminaComO = new TerminaComO();
            string word = "Bad";

            // act
            bool result = terminaComO.AvaliarCriterio(word);
            
            // assert
            Assert.False(result);            
        }

        [Test]
        public void ContemG_AvaliarCriterio_ContainsGUpper_ReturnsTrue()
        {
            // arrange 
            ContemG contemG = new ContemG();
            string word = "Right";

            // act
            bool result = contemG.AvaliarCriterio(word);
            
            // assert
            Assert.True(result);
        }

        [Test]
        public void ContemG_AvaliarCriterio_ContainsGLower_ReturnsTrue()
        {
            // arrange 
            ContemG contemG = new ContemG();
            string word = "right";

            // act
            bool result = contemG.AvaliarCriterio(word);
            
            // assert
            Assert.True(result);
        }
        
        [Test]
        public void ContemG_AvaliarCriterio_NoG_ReturnsFalse()
        {
            // arrange 
            ContemG contemG = new ContemG();
            string word = "Bad";

            // act
            bool result = contemG.AvaliarCriterio(word);
            
            // assert
            Assert.False(result);            
        }

        [Test]
        public void ContemP_AvaliarCriterio_ContainsPUpper_ReturnsTrue()
        {
            // arrange 
            ContemP contemP = new ContemP();
            string word = "Pass";

            // act
            bool result = contemP.AvaliarCriterio(word);
            
            // assert
            Assert.True(result);
        }

        [Test]
        public void ContemP_AvaliarCriterio_ContainsPLower_ReturnsTrue()
        {
            // arrange 
            ContemP contemP = new ContemP();
            string word = "pass";

            // act
            bool result = contemP.AvaliarCriterio(word);
            
            // assert
            Assert.True(result);
        }
        
        [Test]
        public void ContemP_AvaliarCriterio_NoP_ReturnsFalse()
        {
            // arrange 
            ContemP contemP = new ContemP();
            string word = "Bad";

            // act
            bool result = contemP.AvaliarCriterio(word);
            
            // assert
            Assert.False(result);            
        }
    }
}