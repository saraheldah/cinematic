import { Guid } from "guid-typescript";
import { Theater } from "src/app/theaters/shared/theater.model";
export class Play {
    id?: Guid;
    title?: string;
    category!: string;
    duration!: number;
    theaterId?: Guid;
}