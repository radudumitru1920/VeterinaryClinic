namespace VetClinicApp.Domain.Entities;
using VetClinicApp.Domain.Enums;
public class Staff{
    public int staffID{get;set;}
    public string Nume{get;set;}=string.Empty;
    public StaffRole Role{get;set;}
}