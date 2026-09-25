namespace VetClinicApp.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using VetClinicApp.Domain.Enums;
public class AssistantRequest{
    required public int RequestId{get;set;}

    required public int staffID{get;set;}

    [Required(ErrorMessage = "Staff is required.")]
    public Staff Staff{get;set;}

    [Required(ErrorMessage = "The date is required.")]
    public DateTime Date{get;set;}
  
  
    [Required(ErrorMessage = "The hour is required.")]
    public DateTime Hour{get;set;}

    [Required(ErrorMessage = "The reason is required.")]
    public string Reason{get;set;}

    [Required(ErrorMessage = "Status is required.")]
    required public RequestStatus Status{get;set;}
}