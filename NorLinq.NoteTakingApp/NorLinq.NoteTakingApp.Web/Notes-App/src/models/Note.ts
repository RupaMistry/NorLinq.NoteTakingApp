import type ColorCode from "./ColorCode";

export default interface Note{
    id: number,
    title: string,
    comment: string,
    createdDate: string,
    colorCode:ColorCode
}