import { Question } from './question';
import { Observable } from 'rxjs';

export class Category {
    id: Number;
    name: String;
    questions: Question[];
}
