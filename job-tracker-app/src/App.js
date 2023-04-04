import {Auth0Provider} from '@auth0/auth0-react'
import LoginButton from './components/LoginButton';
import Profile from './components/Profile'
const domain = process.env.REACT_APP_JOB_TRACKER_APP_AUTH0_DOMAIN;
const clientId = process.env.REACT_APP_JOB_TRACKER_APP_AUTH0_CLIENT_ID;

const App = () => {
  return (
    <Auth0Provider responseType = 'code' domain={domain} clientId= {clientId}    authorizationParams={{
      redirect_uri: window.location.origin,
      audience: "https://dev-27tgvrxpujzp1vcw.us.auth0.com/api/v2/",
      scope: "openid profile email"
    }}>
      <LoginButton />
      <Profile />

    </Auth0Provider>
  );
}

export default App;
