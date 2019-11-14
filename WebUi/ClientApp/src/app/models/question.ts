import { Category } from './category';

export class Question {
    questionId: Number;
    message: String;
    answer: String;
    categoryId: Number;
    category: Category;
}
