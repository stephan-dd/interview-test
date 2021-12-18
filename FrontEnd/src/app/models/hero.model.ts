import { KeyValue } from "./key-value.model";

export class Hero {
    public Name: string;
    public Power: string;
    public Stats: Array<KeyValue<string, number>>
}
