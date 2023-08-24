import * as yup from "yup";

const categoryCreationSchema = yup.object({
    title: yup.string().required().min(2, 'Title must be at least 2 letters long'),
    description: yup.string().required()
})

export type ProductCreationData = yup.InferType<typeof categoryCreationSchema>

export default categoryCreationSchema