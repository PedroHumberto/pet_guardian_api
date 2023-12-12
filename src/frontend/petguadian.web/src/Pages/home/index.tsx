import './index.css'
import homeImg from '../../img/img-pets-home2.jpg'
import { NavBar } from '../../Components/NavBar'
import { Sections } from '../../Components/Sections'

export const Home = () => {
    return (
        <>
            <div className="index-container">
                <NavBar/>
                <img src={ homeImg } alt="Img inicial" />
                <div className='sub-container'> 
                    <div className="page-sections">
                        <Sections/>
                    </div>
                </div>
            </div>
        </>
    )
}

export default Home;