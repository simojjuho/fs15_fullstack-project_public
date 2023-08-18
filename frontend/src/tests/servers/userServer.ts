import { rest } from 'msw'
import { setupServer } from 'msw/node'
import singleUser from '../data/users/singleUser'
import listOfUsers from '../data/users/listOfUsers'


const productServer = setupServer(
    rest.post('https://api.escuelajs.co/api/v1/auth/login', async (req, res, ctx) => {
        const credentials = await req.json()
        return res(
            ctx.json({
                access_token: '12345',
                refresh_token: '23456'
            })
        ) 
    }),
    //TODO: If time, this should be made further for testing unauthorized login also!
    rest.get('https://api.escuelajs.co/api/v1/auth/profile', (req, res, ctx) => {
        if (req.headers) {
            return res(
                ctx.json(singleUser)
            )
        }
    }),
    rest.post('https://api.escuelajs.co/api/v1/users/', async (req, res, ctx) => {
        return res(
            ctx.json(singleUser)
        )
    }),
    rest.get('https://api.escuelajs.co/api/v1/users', (req, res, ctx) => {
        return res(
            ctx.json(listOfUsers)
        )
    })
)

export default productServer