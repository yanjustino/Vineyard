namespace Orders.Models.Specifications.Assertions;

public class CustomerRules
{
    /// <summary>
    /// No Brasil, o consumo de bebidas alcoólicas por menores de 18 anos
    /// é proibido. A Lei federal 13.106/16 alterou o Estatuto da Criança
    /// e do Adolescente, tornando crime vender, fornecer, servir, ministrar
    /// ou entregar bebida alcoólica a criança ou adolescente.
    /// <see href="https://www.planalto.gov.br/ccivil_03/_ato2015-2018/2015/lei/l13106.htm"/>
    /// </summary>
    public class IsOfLegalAge : ISpecification<Customer>
    {
        public bool IsMatch(Customer customer) => customer.CalculateAge() >= 18;
    }
    
    /// <summary>
    /// Regra de primeira compra definida pelo Gestor do Departamento de Marketing
    /// e acolhida pelo gerente de vendas durante a Black Friday
    /// de 2022.
    /// <see href="https://sistema-interno/features/98098999"/>
    /// </summary>
    public class IsFisrtPurchase : ISpecification<Customer>
    {
        public bool IsMatch(Customer customer) => customer.DateOfFirstPurchase is null;
    }  
    
    /// <summary>
    /// Implantação do programa de fidelidade após resultados da
    /// Black Friday de 2022 
    /// <see cref="IsFisrtPurchase"/>
    /// <see href="https://sistema-interno/features/99090000"/>
    /// </summary>
    public class IsLoyalCustomers(int years) : ISpecification<Customer>
    {
        public bool IsMatch(Customer customer) => customer.DateOfFirstPurchase < DateTime.Now.AddYears(years * -1);
    }     
}