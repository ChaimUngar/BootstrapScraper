import 'bootstrap/dist/css/bootstrap.min.css';
import { Link } from 'react-router-dom';
import './Home.css';

const Home = () => {

    return (
        <div className="app-container">
            <div className="d-flex flex-column justify-content-center align-items-center">
                <h1 className="display-1">Bootstrap Icon Search</h1>
                <Link to="/search">
                    <h6 className="display-6">Click here to search!</h6>
                </Link>
            </div>
        </div>
    );
};

export default Home;