import { Button, Dialog, DialogActions, DialogContent, DialogTitle, TextField } from '@mui/material'
import { useForm, Controller } from 'react-hook-form'
import { yupResolver } from '@hookform/resolvers/yup';

import useAppSelector from '../../hooks/useAppSelector'
import useAppDispatch from '../../hooks/useAppDispatch'
import { setRegistrationVisibility } from '../../redux/reducers/modalReducer'
import registrationFormSchema, { RegistrationFormData } from '../../validation/registrationFormSchema'
import NewUser from '../../types/NewUser';
import { registerUser, initializeUserNotification } from '../../redux/reducers/userReducer';
import { useEffect  } from 'react';
import Notification from '../Notification';
import useFileInput from '../../hooks/useFileInput';
import fileUploadService from '../../utils/fileUploadService';

const RegisterModal = () => {
    const isOpen = useAppSelector(state => state.modalReducer.registrationModal)
    const dispatch = useAppDispatch()
    const users = useAppSelector(state => state.userReducer)
    const fileInput = useFileInput()
    const { handleSubmit, control, formState: { errors }, reset } = useForm<RegistrationFormData>({
        defaultValues: {
            name: '',
            email: '',
            password: '',
            repeat: '',
        },
        resolver: yupResolver(registrationFormSchema)
    })
    useEffect(() => {
        reset()
        dispatch(initializeUserNotification())
    }, [isOpen, reset, dispatch])
    const onSubmit = async (data: RegistrationFormData) => {
        const images: {file: File}[] = []
        if (fileInput.file) {
            for (let i = 0; i < fileInput.file.length; i++) {
                images.push({file: fileInput.file[i]})
            }
        }
        const location = await fileUploadService(images)
        const newUser: NewUser = {
            name: data.name,
            email: data.email,
            password: data.password,
            avatar: location[0]
        }
        dispatch(registerUser(newUser))
        console.log(newUser)
        setTimeout(() => {
            dispatch(setRegistrationVisibility())
        }, 6000)
    }
    const handleClose = () => {
        dispatch(setRegistrationVisibility())
    }
    const iterateFileList = () => {
        if (fileInput.file) {
            let  fileNames : {name: string, size: number}[] = []
            for (let i = 0; i < fileInput.file.length; i++) {
                fileNames.push({name: fileInput.file[i].name, size: fileInput.file[i].size})
            }
            return fileNames
        }
    }
    const handleRemoveClick = () => {
        fileInput.setFile(undefined)
    }
    return (
        <Dialog open={isOpen} onClose={handleClose} maxWidth='sm'>
            <DialogTitle>Sign up</DialogTitle>
            {users.isSuccess
                ? <Notification message={'Profile created succesfully! You can now sign in using your login information'} severity={'success'} type='user'/> 
                : users.notification
                ? <Notification message={users.notification} severity={'error'} type='user'/>
                : null}
            <DialogContent className='modalForm'  sx={{ display: 'flex', flexDirection: 'column', gap: 1}}>
                <Controller 
                    name="name"
                    control={control}
                    rules={{ required: true }}
                    render={({ field }) => 
                        <TextField
                            { ...field }
                            placeholder='Your email address'
                            label={errors.name?.message ? errors.name?.message : 'Name'} 
                            color={ errors.name?.message ? 'warning' : 'secondary' }
                            className='formInput'
                        />}           
                />
                <Controller 
                    name="email"
                    control={control}
                    rules={{ required: true }}
                    render={({ field: {onChange} }) => 
                        <TextField
                            onChange={onChange}
                            placeholder='Your email address'
                            label={'Email'} 
                            color='secondary'
                            className='formInput'
                        />}           
                />
                <Controller 
                    name="password"
                    control={control}
                    rules={{ required: true }}
                    render={({ field: {onChange} }) => 
                        <TextField
                            onChange={onChange}
                            error={errors.password?.message !== undefined}
                            helperText={errors.password?.message}
                            placeholder='Your password'
                            label={'Password'} 
                            type='password'
                            color='secondary'
                            className='formInput'
                        />}           
                />
                <Controller 
                    name="repeat"
                    control={control}
                    rules={{ required: true }}
                    render={({ field: {onChange} }) => 
                        <TextField
                            onChange={onChange}
                            error={errors.repeat?.message !== undefined}
                            helperText={errors.repeat?.message}
                            placeholder='Your password again'
                            label={'Repeat password'}
                            type='password' 
                            color='secondary'
                            className='formInput'
                        />}           
                /> 
                {iterateFileList() &&<ul>
                File to upload
                { iterateFileList()?.map(item =>
                    <li key={item.size}>
                        {item.name} 
                    </li>)}
                </ul>}
                {iterateFileList() && <Button onClick={handleRemoveClick} variant='outlined' color='secondary'>Remove File</Button>}
                <Button
                    variant="outlined"
                    color='secondary'
                    component="label"
                    className='formInput'
                    >
                    Upload File
                    <input
                        type="file"
                        hidden
                        onChange={e => fileInput.onChange(e)}
                    />
                </Button>
            </DialogContent>
            <DialogActions>
                <Button onClick={handleSubmit(onSubmit)} color='secondary' variant='outlined'>Sign up</Button>
                <Button onClick={handleClose} color='secondary' variant='outlined'>Cancel</Button>
            </DialogActions>
        </Dialog>
  )
}

export default RegisterModal