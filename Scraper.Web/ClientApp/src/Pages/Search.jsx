import { useState } from "react"
import axios from "axios"

const Search = () => {
    const [icons, setIcons] = useState([])
    const [searchText, setSearchText] = useState('')
    const [loading, setLoading] = useState(false)

    const onFormSubmit = async e => {
        e.preventDefault()
        setLoading(true)
        const { data } = await axios.get(`/api/bootstrapscraper/search-icons?text=${searchText}`)
        console.log(data)
        setIcons(data)
        setLoading(false)
    }

    return (
        <>
            <h2 style={{ marginTop: 80 }}>Search for Icons</h2>
            <form>
                {loading && (
                    <div className="text-center">
                        <div className="spinner-border text-primary" role="status" style={{ width: '5rem', height: '5rem' }}>
                            <span className="visually-hidden">Loading...</span>
                        </div>
                    </div>
                )}
                {!loading && (
                    <div className="input-group mb-3">
                        <input type="text" className="form-control" placeholder="Enter icon name, category or description"
                            onChange={(e) => setSearchText(e.target.value)} value={searchText}></input>
                        <button className="btn btn-primary" type="submit" onClick={onFormSubmit}>Search</button>
                    </div>
                )}
            </form>

            <ul id="icons-list" className="row row-cols-3 row-cols-sm-4 row-cols-lg-6 row-cols-xl-8 list-unstyled list">
                {icons.map(i =>
                    <li className="col mb-4" data-name={i.title} data-tags={i.tags} data-categories={i.category}>
                        <a className="d-block text-body-emphasis text-decoration-none" href={i.url} target="_blank">
                            <div className="px-3 py-4 mb-2 bg-body-secondary text-center rounded">
                                <i className={`bi bi-${i.title}`}></i>
                            </div>
                            <div className="name text-muted text-decoration-none text-center pt-1">{i.title}</div>
                        </a>
                    </li>
                )}
            </ul>
        </>
    )
}

export default Search