namespace VetClinicApp.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using VetClinicApp.Domain.Enums;
public class AssistantRequest{
    required public int RequestId{get;set;}

    public DateTime Date{get;set;}
  
    public DateTime Hour{get;set;}

    public string Reason{get;set;}

    required public RequestStatus Status{get;set;}
}