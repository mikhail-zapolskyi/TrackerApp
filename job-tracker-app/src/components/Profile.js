import {useEffect} from 'react'
import { useAuth0 } from '@auth0/auth0-react'

const Profile = () => {
    const { logout, user, isAuthenticated,getAccessTokenSilently } = useAuth0();
    const {name,picture} = user ? user : {};
    useEffect(() => {
        callBackendAPI()
      }, [])
    async function callBackendAPI(){
        const jwtToken = await getAccessTokenSilently();
        try{
            await fetch('http://localhost:8000',{
                headers:{
                    authorization: `Bearer ${jwtToken}`
                }

            })
            .then(response =>{
                return response.json()
            })
            .then (data =>{
                console.log(data)
                console.log(getAccessTokenSilently())
            })
        }
        catch(e){
            console.log(e)
        }

    }

    return (
        <>
            {isAuthenticated && (
                <>
                    <p>{name}</p>
                    <img src={picture} alt='test' />
                    <button onClick={() => logout()}>
                        Sign Out
                    </button>
                </>

            )
            }
        </>

    )
}

export default Profile
