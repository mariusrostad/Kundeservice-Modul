import { Category } from './category';
import { Answer } from './answer';

export class Question {
    id: Number;
    message: String;
    category: Category;
    answers: Answer[];
}
