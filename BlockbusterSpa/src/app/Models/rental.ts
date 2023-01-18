import { DatePipe } from "@angular/common";
import { Data } from "@angular/router";

export interface rentals {
    id: number;
    movie: string;
    userName: string;
    email: string,
    data: Date
}