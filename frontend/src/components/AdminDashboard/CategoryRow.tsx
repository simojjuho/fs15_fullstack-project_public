import { TableCell, TableRow } from "@mui/material"
import Category from "../../types/Category"

interface CategoryRowProps {
  category: Category
}

const CategoryRow = ({category}: CategoryRowProps) => {

  return (
    <TableRow>
      <TableCell>{category.title}</TableCell>
      <TableCell>{category.description}</TableCell>
    </TableRow>
  )
}

export default CategoryRow