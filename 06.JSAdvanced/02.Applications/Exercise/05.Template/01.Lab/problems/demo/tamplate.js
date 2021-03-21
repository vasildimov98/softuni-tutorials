const articleTemplate = `
        <article>
            <header>
                <h3>{{title}}</h3>
            </header>
            
            <section>
                <p>{{content}}</p>
            </section>
        {{#if author}}
          <footer>
                Author: {{author}}
            </footer>
        {{/if}}
        </article>`;

export default articleTemplate;