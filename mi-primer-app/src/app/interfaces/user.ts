import { Address } from "./address";

export interface User {
    id: number;
    userName: string;
    name: string;
    lastName: string;
    age: number;
    dateCreated: string;
    addresses: Address;
}