﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Domain.Entity
{
    public class JobModel
    {
        [Key]
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Deadline { get; set; }
        public double Payment { get; set; }
        public bool IsPaymentByHour { get; set; }
        public string? AssignedFreelancerId { get; set; }
        public string ClientId { get; set; }

        [ForeignKey("ClientId")]
        public UserModel Client { get; set; }

        [ForeignKey("AssignedFreelancerId")]
        public UserModel? AssignedFreelancer { get; set; }
        public bool Active { get; set; }
        public bool Available { get; set; }

        public JobModel(string id, string title, int deadline, string description, double payment, bool isPaymentByHour, UserModel client, UserModel assignedFreelancer, bool active, bool available)
        {
            Id = id;
            Title = title;
            Description = description;
            Payment = payment;
            Deadline = deadline;
            IsPaymentByHour = isPaymentByHour;
            Client = client;
            AssignedFreelancer = assignedFreelancer;
            Active = active;
            Available = available;
            AssignedFreelancerId = assignedFreelancer?.Id;
            ClientId = client.Id;
        }

        public JobModel(string id, string title, int deadline, string description, double payment, bool isPaymentByHour, string client, string? assignedFreelancer, bool active, bool available)
        {
            Id = id;
            Title = title;
            Deadline = deadline;
            Description = description;
            Payment = payment;
            IsPaymentByHour = isPaymentByHour;
            ClientId = client;
            AssignedFreelancerId = assignedFreelancer;
            Active = active;
            Available = available;
        }

        public JobModel()
        {

        }

        public static JobModel FromDomainObject(Job job)
        {
            if(job == null)
            {
                return null;
            }
            return new JobModel(job.Id, job.Title, job.Deadline, job.Description, job.Payment, job.IsPaymentByHour, job.Client.Id, 
                    job?.AssignedFreelancer?.Id, job.Active, job.Available);
        }
    }
}
