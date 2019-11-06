import { Category } from './category';
import { Rating } from './rating';

export class Question {
    id: Number;
    message: String;
    category: Category;
    rating: Rating;
}
