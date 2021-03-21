function solve() {
    let bugTracker = (() => {
        let bugsContainer = [];
        let currId = 0;
        let selector = undefined;

        let report = function (author, description, reproducible, severity) {
            bugsContainer[currId] = {
                ID: currId++,
                author,
                description,
                reproducible,
                severity,
                status: 'Open',
            };

            if (selector) {
                updateHTML();
            }
        };

        let setStatus = function (id, newStatus) {
            bugsContainer[id].status = newStatus;

            if (selector) {
                updateHTML();
            }
        };

        let remove = function (id) {
            bugsContainer
                = bugsContainer.filter(b => b.ID != id);

            if (selector) {
                updateHTML();
            }
        };

        let sort = function (criteria) {
            switch (criteria) {
                case 'author':
                    bugsContainer.sort((a, b) => a.author.localeCompare(b.author));
                    break;
                case 'severity':
                    bugsContainer.sort((a, b) => a.severity - b.severity);
                    break;
                default:
                    bugsContainer.sort((a, b) => a.ID - b.ID);
                    break;
            }

            if (selector) {
                updateHTML();
            }
        };

        let output = function (sel) {
            selector = sel;
        };

        function updateHTML() {
            $(selector).html("");
            for (let bug of bugsContainer) {
                $(selector)
                    .append($('<div>')
                        .attr('id', "report_" + bug.ID)
                        .addClass('report')
                        .append($('<div>')
                            .addClass('body')
                            .append($('<p>')
                                .text(bug.description)))
                        .append($('<div>')
                            .addClass('title')
                            .append($('<span>')
                                .addClass('author')
                                .text('Submitted by: ' + bug.author))
                            .append($('<span>')
                                .addClass('status')
                                .text(bug.status + " | " + bug.severity))));
            }
        }

        return { report, setStatus, remove, sort, output };
    })();

    return bugTracker;
}
