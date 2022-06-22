describe('Fluxo do cliente', () => {
  it('Teste 1: Visita página', () => {
    cy.visit('http://localhost:3000/')
  })

  it('Teste 2: Login no sistema', () => {
    cy.get('[data-testid="email-input"]')
      .type('cliente@email.com')
      .should('have.value', '')

    cy.get('[data-testid="password-input"]')
      .type('senha')
      .should('have.value', '')

    cy.get('[data-testid="login-button"]')
      .click()
  })

  it('Teste 3: Verifica redirecionamento', () => {
    cy.url().should('include', '/home')

    cy.get('[data-testid="newjob-button"]')
      .click()
  })

  it('Teste 4: Cria novo job', () => {
    cy.get('[data-testid="title-input"]')
      .type('Job')
      .should('have.value', '')

    cy.get('[data-testid="description-input"]')
      .type('Job description')
      .should('have.value', '')
  
    cy.get('[data-testid="deadline-input"]')
      .type('13')
      .should('have.value', '')

    cy.get('[data-testid="skill-input"]')
      .type('Skill')
      .should('have.value', '')

    cy.get('[data-testid="addskill-button"]')
      .click()

    cy.get('[data-testid="Skill-text"]')

    cy.get('[data-testid="perhour-checkbox"]')
      .click()

    cy.get('[data-testid="payment-input"]')
      .type('50')
      .should('have.value', '')

    cy.get('[data-testid="createjob-button"]')
      .click()
  })

  it('Teste 5: Verifica se o job criado é exibido corretamente na listagem de jobs', () => {
    cy.url().should('include', '/jobs-list/true')

    cy.get('[data-testid="search-input"]')
      .type('Job')
      .should('have.value', '')

    cy.get('[data-testid="skills-div"]')
      .contains('Skill')

    cy.get('[data-testid="Job-button"]')
      .first().click()
  })

  it('Teste 6: Verifica se o job foi criado com os atributos corretos', () => {
    cy.url().should('include', '/client-job-view')

    cy.get('[data-testid="title-div"]')
      .contains('Job')

    cy.get('[data-testid="description-div"]')
      .contains('Job description')

    cy.get('[data-testid="price-div"]')
      .contains('R$ 50/h')

    cy.get('[data-testid="freelancers-div"]')
      .contains('Job ainda sem ofertas!')
  })

  it('Teste 7: Faz o logout', () => {
    cy.get('[data-testid="menu-button"]')
      .click()

    cy.get('[data-testid="logout-button"]')
      .click()

    cy.get('[data-testid="login-button"]')
  })

})

describe('Fluxo do freelancer', () => {
  it('Teste 1: Visita página', () => {
    cy.visit('http://localhost:3000/')
  })

  it('Teste 2: Login no sistema', () => {
    cy.get('[data-testid="email-input"]')
      .type('freelancer@email.com')
      .should('have.value', '')

    cy.get('[data-testid="password-input"]')
      .type('senha')
      .should('have.value', '')

    cy.get('[data-testid="login-button"]')
      .click()
  })

  it('Teste 3: Verifica redirecionamento', () => {
    cy.url().should('include', '/home')

    cy.get('[data-testid="findjobs-button"]')
      .click()
  })

  it('Teste 4: Verifica se o freelancer está na página contendo a listagem de jobs adequada', () => {
    cy.url().should('include', '/jobs-list/false')
  })

  it('Teste 5: Filtra os jobs de acordo com os parâmetros desejados', () => {
    cy.get('[data-testid="perhour-checkbox"]')
      .click()

    cy.get('[data-testid="perhourlower-input"]')
      .type('50')
      .should('have.value', '')

    cy.get('[data-testid="perhourupper-input"]')
      .type('50')
      .should('have.value', '')

    cy.get('[data-testid="deadlinelower-input"]')
      .type('13')
      .should('have.value', '')

    cy.get('[data-testid="deadlineupper-input"]')
      .type('13')
      .should('have.value', '')

    cy.get('[data-testid="skill-input"]')
      .type('Skill')
      .should('have.value', '')

    cy.get('[data-testid="addskill-button"]')
      .click()

    cy.get('[data-testid="Job-button"]')
      .first().click()
  })

  it('Teste 6: Verifica que as informações do job realmente concidem com o job exibido após aplicação dos filtros', () => {
    cy.get('[data-testid="price-div"]')
      .contains('R$ 50/h')

    cy.get('[data-testid="skills-div"]')
      .contains('Skill')
  })

  it('Teste 7: Candidata-se para o job selecionado e verifica que realmente está candidatado', () => {
    cy.get('[data-testid="apply-button"]')
      .click()

    cy.reload()

    cy.get('[data-testid="apply-button"]')
      .should('have.value', '')
  })

  it('Teste 8: Faz o logout', () => {
    cy.get('[data-testid="menu-button"]')
      .click()

    cy.get('[data-testid="logout-button"]')
      .click()

    cy.get('[data-testid="login-button"]')
  })
})