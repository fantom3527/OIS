import { FC, ReactElement, useEffect, useState } from 'react';
import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';
import './App.css';
import userManager, { loadUser, signinRedirect } from './auth/user-service';
import AuthProvider from './auth/auth-provider';
import SignInOidc from './auth/SigninOidc';
import SignOutOidc from './auth/SignoutOidc';
import CityList from './features/CityList';

const App: FC<{}> = (): ReactElement => {

  const [isUserLoad, setIsUserLoad] = useState(false);

  useEffect(() => {
    const userLoadedHandler = () => {
      setIsUserLoad(true);
    };

    userManager.events.addUserLoaded(userLoadedHandler);

    return () => {
      userManager.events.removeUserLoaded(userLoadedHandler);
    };
  }, []);

  useEffect(() => {
    loadUser().then(result => {
      setIsUserLoad(result);
    });
  }, []);
  
  return (
    <div className="App">
    <header className="App-header">
        <button onClick={() => signinRedirect()}>Login</button>
        <AuthProvider userManager={userManager}>
            <Router>
                <Routes>
                    <Route path="/" element={<CityList isUserLoad = {isUserLoad}/>} />
                    <Route
                        path="/signout-oidc"
                        element={<SignOutOidc/>}
                    />
                    <Route path="/signin-oidc" element={<SignInOidc/>} />
                </Routes>
            </Router>
        </AuthProvider>
    </header>
  </div>
  );
}

export default App;
