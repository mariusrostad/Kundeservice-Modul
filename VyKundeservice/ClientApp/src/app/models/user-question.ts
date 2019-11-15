export class UserQuestion {
    private question: String;
    private category: Number;
    constructor(
        question: String,
        category: Number,
    ) {
        this.category = category;
        this.question = question;
    }
}
