import Category from "./Category"

type CategoryCreate = Omit<Category, 'id'>

export default CategoryCreate