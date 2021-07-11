import { Currency } from "./currency";
import { Languages } from "./languages";

export interface Country {
    name: string;
    capital: string;
    flag: string;
    region: string;
    alpha3Code: string;
}

export class Country {
    name: string;
    capital: string;
    flag: string;
    currencies: Currency[];
    population: number;
    timezones: string[];
    borders: string[];
    languages: Languages[]
}