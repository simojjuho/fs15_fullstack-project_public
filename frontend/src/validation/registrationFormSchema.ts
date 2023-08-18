import * as yup from "yup";

const registrationFormSchema = yup.object({
    name: yup
        .string()
        .required()
        .min(2, 'Name must be at least 2 letters long'),
    email: yup
        .string()
        .email()
        .required('Email cannot be empty'),
    password: yup
        .string()
        .required()
        .matches(/^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])/, 'Password must have at least one capital letter (A-Z), one lower case letter (a-z) and at least one number')
        .min(6, 'Password must be at least 6 characters long!'),
    repeat: yup
        .string()
        .required()
        .oneOf([yup.ref('password')], 'Passwords don\'t match'),
})

export type RegistrationFormData = yup.InferType<typeof registrationFormSchema>

export default registrationFormSchema