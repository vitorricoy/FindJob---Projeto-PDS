export default class ApplyJobInput {
    jobId: string;
    userId: string;

    constructor(jobId: string, userId: string) {
        this.jobId = jobId;
        this.userId = userId;
    }
}