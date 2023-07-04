using System;
using SquareEquationLib;
using TechTalk.SpecFlow;
namespace BDD.Tests{
    [Binding]
    public class BDD{
        private ScenarioContext _scenarioContext;
        private double a, b, c;
        private double[] result = new double[2];
        private bool mis;
        public BDD(ScenarioContext input){
            _scenarioContext = input;
        }
        [Given(@"Квадратное уравнение с коэффициентами \((.*), (.*), (.*)\)")]
        public void Input_with_Double_Numbers(string k1, string k2, string k3){
            try{
            a=Convert.ToDouble(k1);
            b=Convert.ToDouble(k2);
            c=Convert.ToDouble(k3);
            }
            catch(System.FormatException){
                mis = false;
            }
        }
        [When(@"вычисляются корни квадратного уравнения")]
        public void Square_Root(){
        try{
            result = SquareEquation.Solve(a,b,c);
        }
        catch (System.ArgumentException){
            mis = false;
        }
        }
        [Then(@"выбрасывается исключение ArgumentException")]
        public void Check_Argument(){
            Assert.False(mis);
        }
        [Then(@"квадратное уравнение имеет два корня \((.*), (.*)\) кратности один")]
        public void Check_Two_Roots(string one, string two){
            var excep = new double[] {Convert.ToDouble(one),Convert.ToDouble(two)};
            var presicion = 5;
            for(int i = 0; i<result.Length; i++){
                Assert.Equal(excep[i],result[i]);
            }
        }
        [Then(@"квадратное уравнение имеет один корень (.*) кратности два")]
        public void Check_One_Root(double number){
            var excep = new double[]{number};
            var presicion = 5;
            Assert.Equal(excep[0],result[0],presicion);
        }
        [Then(@"множество корней квадратного уравнения пустое")]
        public void Check_No_Roots(){
            Assert.Empty(result);
        }
        

    }
}