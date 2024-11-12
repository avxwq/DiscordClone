import { useEffect } from 'react';
import { useStore } from '../stores/store';
import HomePage from './homePage';
import NavBar from './navBar';
import SideBar from './sideBar';
import './styles.css';
import { Outlet, useLocation, useNavigate } from 'react-router-dom';
import AdminPanel from '../../features/Admin/AdminPanel';
import { ThemeProvider } from '@emotion/react';
import theme from '../theme/theme';

function App() {

    const location = useLocation();
    const { userStore } = useStore();
    const navigate = useNavigate();

    useEffect(() => {
        if (location.pathname === '/main' && !userStore.getLoggedIn()) {
            navigate('/login');
        }
    }, [location.pathname, userStore, navigate]);

    return (
        <ThemeProvider theme={theme}>
        <>
            {location.pathname === '/' ? <HomePage /> : (
                <>
                    {location.pathname !== '/login' ? (
                        <>
                            {userStore.user?.role === 'Admin' ? (
                                <AdminPanel />
                            ) : (
                                <>
                                    <NavBar />
                                    <SideBar />
                                    <Outlet />
                                </>
                            )}
                        </>
                    ) : (
                        <Outlet />
                    )}
                </>
            )}
            </>
        </ThemeProvider>
    );
}

export default App;
