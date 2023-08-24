import { yupResolver } from "@hookform/resolvers/yup"
import { Dialog, DialogContent, TextField, Button, DialogActions } from "@mui/material"
import { Controller, useForm } from "react-hook-form"
import CategoryCreate from "../../types/CategoryCreate"
import useAppDispatch from "../../hooks/useAppDispatch"
import { createCategory } from "../../redux/reducers/categoryReducer"
import categoryCreationSchema from "../../validation/categoryCreationSchema"

interface AddNewCategoryProps {
  isVisible: boolean
  setVisible: React.Dispatch<React.SetStateAction<boolean>>
}

const AddNewCategory = ({isVisible, setVisible}: AddNewCategoryProps) => {
  const handleModalClose = () => setVisible(false)
  const dispatch = useAppDispatch()
  const { handleSubmit, control, formState: { errors }, reset } = useForm<CategoryCreate>({
    defaultValues: {
        title: '',
        description: ''
    },
    resolver: yupResolver(categoryCreationSchema)
  })
  const onSubmit = async (data: CategoryCreate) => {
    const newCategoryData: CategoryCreate = {
        title: data.title,
        description: data.description,
    }
    dispatch(createCategory(newCategoryData))
    handleModalClose()
  }
  return (
  <Dialog open={isVisible} onClose={handleModalClose}>
  <DialogContent sx={{ display: 'flex', flexDirection: 'column'}}>
    <Controller 
      name="title"
      control={control}
      rules={{ required: true }}
      render={({ field }) => 
      <TextField
          { ...field }
          placeholder='Category title'
          label={errors.title?.message ? errors.title?.message : 'Title'} 
          color={ errors.title?.message ? 'warning' : 'secondary' }
          className='formInput'
      />}           
    />
    <Controller 
      name="description"
      control={control}
      rules={{ required: true }}
      render={({ field }) => 
      <TextField
          { ...field }
          placeholder='Description'
          type='number'
          multiline
          rows={4}
          label={errors.description?.message ? errors.description?.message : 'Description'} 
          color={ errors.description?.message ? 'warning' : 'secondary' }
          className='formInput'
      />}           
    />
  </DialogContent>
  <DialogActions>
      <Button variant='outlined' color='secondary' onClick={handleSubmit(onSubmit)}>Add</Button>
      <Button variant='outlined' color='secondary' onClick={handleModalClose}>Cancel</Button>
  </DialogActions>
</Dialog>
)
}

export default AddNewCategory