import { Guid } from "guid-typescript";

export interface User {
    id?: Guid;
    username: string;
    email?: string;
    password: string;
    phone?: string;
    role?: number;
}
