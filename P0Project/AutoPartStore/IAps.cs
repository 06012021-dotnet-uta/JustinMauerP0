namespace AutoPartStore
{
    public interface IAps
    {
        Customer login();
        AutoPartStoreDbContext.Customer CustomerRegistration();
        

    }
}