export interface Book{
    id?: number,
    title: string,
    description: string,
    author: string,
    category: string,
    created? : Date,
    updated? : Date,
}