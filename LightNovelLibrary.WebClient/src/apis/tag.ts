export function getTags() {
    return Promise.resolve([
        { 
            id: 1,
            name: 'Tag1'
        },
        { 
            id: 2,
            name: 'Tag2'
        },
    ])
}