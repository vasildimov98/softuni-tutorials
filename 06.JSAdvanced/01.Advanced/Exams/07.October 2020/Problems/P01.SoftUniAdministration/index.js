function solve() {
    //select addBtn
    let addBtn = document
        .querySelector('.form-control button');

    //select all inputs
    let [lectureNameInput,
        lectureDateInput,
    ] = document
        .querySelectorAll('.form-control input[name]');

    let lectureModuleInput = document
        .querySelector('.form-control select[name]');

    // select modulesList
    let modulesList = document
        .querySelector('.modules');

    //add event 
    addBtn
        .addEventListener('click', addNewModule);

    function addNewModule(e) {
        e.preventDefault();

        let lecture = lectureNameInput.value;
        let dateValue = lectureDateInput.value;
        let module = lectureModuleInput.value;

        if (!lecture
            || !dateValue
            || module == 'Select module') {
            return;
        }

        let [date, time] = dateValue
            .split('T');

        date = date.replace(/-/g, '/');

        let currModules = Array
            .from(document
                .querySelectorAll('.module h3'));

        let newModuleElement = currModules
            .find(h => h.textContent
                .includes(`${module.toUpperCase()}`));

        if (!newModuleElement) {
            newModuleElement = createNewModule(module);
        } else {
            newModuleElement = newModuleElement
                .parentElement;
        }

        var moduleList = newModuleElement
            .querySelector('ul');

        appendNewLecture(moduleList, lecture, date, time);

        lectureNameInput.value = '';
        lectureDateInput.value = '';
    }

    function createNewModule(module) {
        let newModuleElement = _createElement('div', {
            name: 'class',
            value: 'module',
        });

        let newTitleForTheModule = _createElement('h3');
        _appendValues(newTitleForTheModule, [`${module.toUpperCase()}-MODULE`]);

        let newListForTheModule = _createElement('ul');

        _appendValues(newModuleElement, [newTitleForTheModule, newListForTheModule]);

        _appendValues(modulesList, [newModuleElement]);

        return newModuleElement;
    }

    function appendNewLecture(moduleList, lecture, date, time) {
        // let titleArr = Array
        //     .from(moduleList
        //         .querySelectorAll('h4')
        //     );

        // let needToBeSort = false;

        // if (titleArr
        //     .some(t => t.textContent
        //         .includes(lecture))) {
        //     needToBeSort = true;
        // }

        let newLectureElement = _createElement('li', {
            name: 'class',
            value: 'flex',
        });

        let lectureTitleElement = _createElement('h4');

        let titleText = `${lecture} - ${date} - ${time}`;

        _appendValues(lectureTitleElement, [titleText]);

        let delBtn = _createElement('button', {
            name: 'class',
            value: 'red',
        });
        _appendValues(delBtn, ['Del']);

        delBtn
            .addEventListener('click', deleteLecture);

        _appendValues(newLectureElement, [lectureTitleElement,
            delBtn]);

        _appendValues(moduleList, [newLectureElement,
        ]);


        sortLecturesByDate(moduleList);
    }

    function deleteLecture(e) {
        let modules = e.target
            .parentElement
            .parentElement;
        e.target.parentElement.remove();

        if (!Array
            .from(modules
                .children)
            .length) {
            modules
                .parentElement
                .remove();
        }
    }

    function sortLecturesByDate(modulesList) {
        let sortLectures = Array
            .from(modulesList
                .children)
            .sort((l1, l2) => {
                let [, date1, time1] = l1
                    .querySelector('h4')
                    .textContent
                    .split('-');

                let [, date2, time2] = l2
                    .querySelector('h4')
                    .textContent
                    .split('-');

                let l1Date = `${date1} - ${time1}`;
                let l2Date = `${date2} - ${time2}`;

                return l1Date.localeCompare(l2Date);
            });

        while (modulesList
            .firstChild) {
            modulesList.firstChild.remove();
        }

        sortLectures
            .forEach(l => {
                modulesList
                    .appendChild(l);
            });
    }

    function _createElement(type, attr) {
        let element = document
            .createElement(type);

        if (attr) {
            let { name, value } = attr;

            element
                .setAttribute(name, value);
        }

        return element;
    }

    function _appendValues(element, valueArr) {
        valueArr
            .forEach(value => {
                if (typeof value != 'object') {
                    let textNode = document
                        .createTextNode(value);

                    value = textNode;
                }

                element.appendChild(value);
            });
    }
};

// result();

// let elements = {
//     form: document.getElementsByTagName('form')[0],
//     name: document.querySelector('input[name="lecture-name"]'),
//     date: document.querySelector('input[name="lecture-date"]'),
//     module: document.querySelector('select[name="lecture-module"]'),
//     addBtn: document.querySelector('form button'),
//     modulesDiv: document.querySelector('.modules'),
//     moduleList: () => Array.from(document.querySelectorAll('.module')),
//     listItems: () => Array.from(document.querySelectorAll('.flex')),
// }

// elements.name.value = "DOM";
// elements.date.value = "2020-09-28T18:00";
// elements.module.value = "Advanced";

// elements.addBtn.click();

// assert.equal(elements.moduleList()[0].children[0].textContent, 'ADVANCED-MODULE', 'Module name incorrect');

// elements.name.value = "Arrays";
// elements.date.value = "2020-09-17T18:00";
// elements.module.value = "Advanced";

// elements.addBtn.click();
// assert.equal(elements.moduleList().length, 1, 'Incorrect amount of modules');
// assert.equal(elements.listItems()[0].children[0].textContent, 'Arrays - 2020/09/17 - 18:00', 'Incorrect lecture appended');

// elements.name.value = "Arrays";
// elements.date.value = "2020-09-30T18:30";
// elements.module.value = "Fundamentals";

// elements.addBtn.click();

// assert.equal(elements.listItems()[0].children[1].className, 'red', 'Incorrect className');