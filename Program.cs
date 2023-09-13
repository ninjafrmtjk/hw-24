using System.Collections;
using System.Collections.Generic;

public class Vehicle : IEnumerable<DetailParts>
{
    public string Name { get; set; }
    public string Company { get; set; }
    public string Color { get; set; }
    public int MaxSpeed { get; set; }
    
    private readonly List<DetailParts> detailPartsList = new List<DetailParts>();
    
    public void AddDetail(DetailParts detailPart)
    {
        detailPartsList.Add(detailPart);
    }
    
    public void RemoveDetail(string name)
    {
        detailPartsList.RemoveAll(dp => dp.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
    }
    
    public DetailParts GetDetailByName(string name)
    {
        return detailPartsList.FirstOrDefault(dp => dp.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
    }
    
    public void ChangeDetailWeight(string name, int weight)
    {
        var dp = GetDetailByName(name);
        if(dp != null)
        {
            dp.Weight = weight;
        }
    }
    
    public void ChangeDetailDescription(string name, string description)
    {
        var dp = GetDetailByName(name);
        if(dp != null)
        {
            dp.Description = description;
        }
    }
    
    public DetailParts this[string name]
    {
        get
        {
            return GetDetailByName(name);
        }
        set
        {
            var dp = GetDetailByName(name);
            if(dp != null)
            {
                dp.Weight = value.Weight;
                dp.Description = value.Description;
            }
        }
    }

     public IEnumerator<DetailParts> GetEnumerator()
    {
        return detailPartsList.GetEnumerator();
    }
    
    IEnumerator IEnumerable.GetEnumerator()
    {
        return detailPartsList.GetEnumerator();
    }
}

public class DetailParts
{
    public string Name { get; set; }
    public int Weight { get; set; }
    public string Description { get; set; }
}