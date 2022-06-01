export default class ApplyJobInput {
    jobId: string;
    freelancerId: string;

    constructor(jobId: string, freelancerId: string) {
        this.jobId = jobId;
        this.freelancerId = freelancerId;
    }
}