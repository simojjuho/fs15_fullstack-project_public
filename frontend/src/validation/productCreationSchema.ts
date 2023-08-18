import * as yup from "yup";

const productCreationSchema = yup.object({
    title: yup.string().required().min(2, 'Title must be at least 2 letters long'),
    price: yup.number().required().min(0, 'Price can not be negative'),
    category: yup.number().required().min(0, 'Category can not be negative'),
    description: yup.string().required()
})

export type ProductCreationData = yup.InferType<typeof productCreationSchema>

export default productCreationSchema