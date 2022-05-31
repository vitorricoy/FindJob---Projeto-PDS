export default class RateJobInput {
    jobId: string;
    rating: number;
    constructor(jobId: string, rating: number) {
        this.jobId = jobId;
        this.rating = rating;
    }
}