import Product from "../../types/Product";

const isString = (text: unknown): text is string => {
    return typeof text === 'string' || text instanceof String;
  };
const stringParser = (property: unknown): string => {
    if(property && isString(property)) {
        return property
    }
    throw new Error('Property was not type of string')
}
const numberParser = (property: unknown): number => {
    if(property && typeof property === 'number') {
        return property
    }
    throw new Error('Property is not a number')
}
const stringArrayParser = (array: unknown): string[] => {
    if(Array.isArray(array)) {
        const newArr: string[] = []
        for (let item of array) {
            const newItem = stringParser(item)
            newArr.push(newItem)
        }
        return newArr
    }
    throw new Error('Not proper images')    
}
export const objectParser = (object: unknown, newId: number): Product => {
    if(object && typeof object === 'object' && 'title' in object && 'price' in object && 'description' in object && 'categoryId' in object && 'images' in object) {
        let newProduct: Product = {
            title: stringParser(object.title),
            price: numberParser(object.price),
            description: stringParser(object.description),
            category: {
                id: numberParser(object.categoryId),
                name: 'Trousers',
                url: 'fakeurl.com'
            },
            creationAt: '16-05-2023',
            images: stringArrayParser(object.images),
            id: Math.floor(Math.random() * 4)
        }
        return newProduct
    }
    throw new Error('Check the data again, could not create a new product object')
}